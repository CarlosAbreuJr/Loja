import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  public active: boolean = false;
  public activeSideBar: boolean = false;
  currentEnum = '';

  constructor() { }

}