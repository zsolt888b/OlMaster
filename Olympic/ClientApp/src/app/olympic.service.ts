import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Olympicon } from './models/olympicon';
import { Nations } from './models/nations';
import { Country } from './models/country';
import { DetailedOlympicon } from './models/detailedolympicon';
import 'rxjs/add/operator/map';  
import { Http } from '@angular/http';

@Injectable()
export class OlympicService {

  private url : string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _http : Http) {
    this.url = baseUrl    
  }

  //getOlympicons(number) {
  //  return this._http.get(this.url + 'api/olympicons/' + number).map(res => res.json());
  //}

  getOlympicons(number) {
    return this.http.get<DetailedOlympicon>(this.url + 'api/olympicons/' + number);
  }

  getOlympiconsByNation() {
    return this.http.get<Nations[]>(this.url + 'api/olympicons/nations');
  }

  getNations() {
    return this.http.get<Country[]>(this.url + 'api/olympicons/nation');
  }
  //getSports() {
    //return this.http.get<Country[]>(this.url + 'api/olympicons/sports');
  //}

  update(id,payload) {
    return this.http.put(this.url +'api/olympicons/' + id, payload);
  }

  newOlympicon(payload){
    return this.http.post(this.url+'api/olympicons',payload);
  }


  search(params){
    return this.http.get<Nations[]>(this.url + 'api/olympicons/search2'+ "?" + params);
  }

}
