import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Hreo',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44355',
    redirectUri: baseUrl,
    clientId: 'Hreo_App',
    responseType: 'code',
    scope: 'offline_access Hreo',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44355',
      rootNamespace: 'PBL6.Hreo',
    },
    Hreo: {
      url: 'https://localhost:44370',
      rootNamespace: 'PBL6.Hreo',
    },
  },
} as Environment;
