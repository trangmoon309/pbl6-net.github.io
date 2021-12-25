using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Volo.Abp.Users;

namespace PBL6.Hreo.Services
{
    public class TestAppService : CrudAppService<
            Test,
            TestResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            TestRequest,
            TestRequest>, 
        ITestAppService
    {
        private readonly ITestRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly ITestQuestionRepository _questionRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IPostRepository _postRepository;
        private readonly IApplicantTestRepository _appTestRepository;
        private readonly IApplicantTestQuestionRepository _appTestQuestionRepository;

        public TestAppService(ITestRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            ITestQuestionRepository questionRepository,
            ICurrentUser currentUser,
            IApplicantTestRepository appTestRepository,
            IApplicantTestQuestionRepository appTestQuestionRepository, 
            IPostRepository postRepository) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _questionRepository = questionRepository;
            _currentUser = currentUser;
            _appTestRepository = appTestRepository;
            _appTestQuestionRepository = appTestQuestionRepository;
            _postRepository = postRepository;
        }

        public override async Task<PagedResultDto<TestResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = _repository.GetList();
            var toList = await _asyncQueryableExecuter.ToListAsync(list);

            var responses = ObjectMapper.Map<List<Test>, List<TestResponse>>(toList);
            var count = responses.Count();
            responses = responses.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<TestResponse>(count, responses);
        }

        public async Task<PagedResultDto<TestResponse>> GetListByCondittion(SearchTestRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var query = _repository.GetList();

                query = query.OrderByDescending(x => x.CreationTime);

                if (request.Status.HasValue)
                {
                    query = query.Where(x => x.Status == request.Status.Value);
                }

                if (!request.KeyWord.IsNullOrEmpty())
                {
                    query = query.Where(x => x.Title.ToLower().Contains(request.KeyWord.ToLower()));
                }

                query = query.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount);

                var toList = await _asyncQueryableExecuter.ToListAsync(query);

                var items = ObjectMapper.Map<List<Test>, List<TestResponse>>(toList);
                var total = items.Count();

                return new PagedResultDto<TestResponse>(total, items);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<TestWithQuestionResponse> CreateWithQuestionsAsync(TestWithQuestionRequest input)
        {
            var createdTest = ObjectMapper.Map<TestWithQuestionRequest, Test>(input);
            EntityHelper.TrySetId(createdTest, GuidGenerator.Create);
            createdTest.CreatorId = _currentUser.Id;

            var testQuestionResponses = new List<TestQuestionResponse>();
            foreach(var item in createdTest.TestQuestions)
            {
                EntityHelper.TrySetId(item, GuidGenerator.Create);
                item.TestId = createdTest.Id;
                testQuestionResponses.Add(ObjectMapper.Map<TestQuestion, TestQuestionResponse>(item));
            }
            await _repository.InsertAsync(createdTest);

            var response = ObjectMapper.Map<Test, TestWithQuestionResponse>(createdTest);
            response.TestQuestions = testQuestionResponses.OrderBy(x => x.OrderIndex).ToList();

            return response;
        }

        public override async Task<TestResponse> GetAsync(Guid id)
        {
            var x = await _repository.GetById(id);
            return ObjectMapper.Map<Test, TestResponse>(x);
        }

        public async Task<TestWithQuestionResponse> UpdateWithQuestionsAsync(Guid id, TestWithQuestionRequest input)
        {
            var updatedTest = await _repository.GetById(id);

            var x = ObjectMapper.Map<TestWithQuestionRequest, TestRequest>(input);
            MapToEntity(x, updatedTest);
            updatedTest.TestQuestions.Clear();
            //_questionRepository.DeleteByTestId(id);

            var testQuestionResponses = new List<TestQuestionResponse>();
            foreach(var item in input.TestQuestions)
            {
                var createdQuestion = ObjectMapper.Map<TestQuestionRequest, TestQuestion>(item);
                EntityHelper.TrySetId(createdQuestion, GuidGenerator.Create);
                createdQuestion.TestId = updatedTest.Id;

                updatedTest.TestQuestions.Add(createdQuestion);
                testQuestionResponses.Add(ObjectMapper.Map<TestQuestion, TestQuestionResponse>(createdQuestion));
            }

            await _repository.UpdateAsync(updatedTest);
            var response = ObjectMapper.Map<Test, TestWithQuestionResponse>(updatedTest);
            response.TestQuestions = testQuestionResponses;

            return response;
        }

        public List<TestQuestionRequest> ImportExcelForCreatingTest(IFormFile importExcelFile)
        {
            try
            {
                var createdTestQuestions = new List<TestQuestionRequest>();

                var memoryStream = new MemoryStream();
                var stream = importExcelFile.OpenReadStream();

                using (var ep = new ExcelPackage(memoryStream, stream))
                {
                    var ws = ep.Workbook.Worksheets["Sheet1"];
                    var results = new List<string>();

                    for (int rw = 1; rw <= ws.Dimension.End.Row; rw++) {
                        if(ws.Cells[rw, 1].Value != null)
                        {
                            var content = ws.Cells[rw, 1].Value.ToString();
                            if(content.Length == 6){
                                results.Add(ws.Cells[rw, 2].Value.ToString());
                            }
                        }
                    }

                    for (int rw = 1; rw <= ws.Dimension.End.Row; rw++)
                    {
                        if(ws.Cells[rw, 1].Value != null)
                        {
                            var content = ws.Cells[rw, 1].Value.ToString();
                            if(content.ToLower().Contains("câu")){
                                
                                var orderIndex = Convert.ToInt32(content.Split(' ')[1]);
                                var newQuestion = new TestQuestionRequest();
                                newQuestion.Content = ws.Cells[rw, 2].Value.ToString();
                                newQuestion.OrderIndex = orderIndex;

                                var index = rw+1;
                                var anwsers = new List<string>();

                                while(ws.Cells[index, 1].Value.ToString().ToLower().Length != 6){
                                    anwsers.Add(ws.Cells[index, 2].Value.ToString());
                                    index++;
                                }
                                newQuestion.Answers = anwsers.JoinAsString(";");
                                newQuestion.Result = ConvertStringAnswerToIndex(results[orderIndex-1]);

                                createdTestQuestions.Add(newQuestion);
                            }
                        }
                    }
                }

                return createdTestQuestions;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int ConvertStringAnswerToIndex(string ans){
            switch(ans) 
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;                              
                default:
                    return 0;
            }
        }

        // Làm bài test
        public async Task<List<TestResponse>> GetTestByPost(Guid id)
        {
            try
            {
                var post = await _postRepository.GetById(id);
                var tests =  post.PostTests.Select(x => x.Test).ToList();

                return ObjectMapper.Map<List<Test>, List<TestResponse>>(tests);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicantTestResponse> MarkAssignment(SendApplicantAssignmentRequest request)
        {
            try
            {
                var test = await _repository.GetById(request.TestId);
                var testQuestionsResponse = ObjectMapper.Map<Test, TestResponse>(test).TestQuestions;

                var diem = 0;

                var applicantTest = new ApplicantTest
                {
                    TestId = request.TestId,
                    ApplicantId = request.ApplicantId,
                    PostId = request.PostId,
                };
                applicantTest.ApplicantTestQuestions = new List<ApplicantTestQuestion>();
                EntityHelper.TrySetId(applicantTest, GuidGenerator.Create);

                foreach (var item in request.TestAssignments)
                {
                    var question = testQuestionsResponse.FirstOrDefault(x => x.Id == item.TestQuestionId);

                    if(question != null)
                    {
                        if (question.Result == item.Choose) ++diem;
                    }

                    var applicantTestQuestion = new ApplicantTestQuestion
                    {
                        ApplicantTestId = applicantTest.Id,
                        TestQuestionId = item.TestQuestionId,
                        Choose = item.Choose
                    };
                    EntityHelper.TrySetId(applicantTestQuestion, GuidGenerator.Create);

                    applicantTest.ApplicantTestQuestions.Add(applicantTestQuestion);
                }

                applicantTest.Result = diem;
                var result =  await _appTestRepository.InsertAsync(applicantTest);

                return ObjectMapper.Map<ApplicantTest, ApplicantTestResponse>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicantTestResponse> GetAssignmentByCondition(Guid applicantId, Guid postId)
        {
            try
            {
                var appTest = _appTestRepository.GetList().Where(x => x.ApplicantId == applicantId && x.PostId == postId);

                var result = await _asyncQueryableExecuter.FirstOrDefaultAsync(appTest);

                return ObjectMapper.Map<ApplicantTest, ApplicantTestResponse>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
