import { Injectable } from '@angular/core';

@Injectable()
export class BaseUrlService {
  
  hosturl: string = 'http://localhost:18033';

  constructor() { }

}
