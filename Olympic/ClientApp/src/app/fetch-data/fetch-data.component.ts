import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent {

  public nations: Olympicon[];

  public url: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl
    this.getOlympiconsByNation();
    //this.getO();
  }

  getOlympiconsByNation() {
    this.http.get<Olympicon[]>(this.url + 'api/olympicons').subscribe(result => {
      this.nations = result;
    })
  }

  //getO() {
  //  this.getOlympicons().subscribe(data => this.nations = data);
  //}

  //getOlympicons() {
  //  return this.http.get(this.url + 'api/olympicons')
  //    .map((response: Response) => response.json()).catch(this.errorHandler);
  //}  


  //errorHandler(error: Response) {
  //  console.log(error);
  //  return Observable.throw(error);
  //} 

}

interface Olympicon {
  Id: number,
  Surname : string,
  Forename : string,
  Sport : Sport,
  Nationality : string
}


interface Nations {
  Nationality: string,
  Olympicons: Array<Olympicon>,
}

export enum Sport {
  Archery = 0,
  Athletics = 1,
  Canoe = 2,
  Cycling = 3,
  Fencing = 4,
  Judo = 5,
  Rowing = 6,
  Triathlon = 7,
  Wrestling = 8
}
