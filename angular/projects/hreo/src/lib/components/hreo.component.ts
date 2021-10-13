import { Component, OnInit } from '@angular/core';
import { HreoService } from '../services/hreo.service';

@Component({
  selector: 'lib-hreo',
  template: ` <p>hreo works!</p> `,
  styles: [],
})
export class HreoComponent implements OnInit {
  constructor(private service: HreoService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
