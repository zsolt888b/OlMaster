import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Nations } from '../models/nations';
import { OlympicService } from '../olympic.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Sport } from '../models/sport.enum';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  public nations: Nations[];

  public url: string;

  public form: FormGroup;

  public params : string;

  public param : HttpParams;

  public sports: Array<string> = ["Archery", "Athletics",
    "Canoe",
    "Cycling",
    "Fencing",
    "Judo",
    "Rowing",
    "Triathlon",
    "Wrestling"];

  constructor(private service : OlympicService, private formBuilder: FormBuilder, private router : Router) {
    this.form = this.formBuilder.group(
      {
        id : 0,
        name: [''],
        age: [''],
        sport: [''],
      }
    )
  }

  newOlympicon() {
    this.router.navigate(['/add-olympicon/']);
  }

  search() {
    this.param = new HttpParams().set('age',this.form.controls['age'].value).set('name',this.form.controls['name'].value)
      .set('sport',this.form.controls['age'].value);
    this.params='?age='+this.form.controls['age'].value+'?name='+this.form.controls['name'].value+
     '?sport='+this.form.controls['sport'].value;
    this.service.search(this.params).subscribe();
  }  

  getOlympiconsByNation() {
    this.service.getOlympiconsByNation().subscribe(result => {
      this.nations = result;
    })
  }

  ngOnInit(): void {
    this.getOlympiconsByNation();
  }

  enumtostring(num) {
    switch(num){
      case 0:
        return "Archery"
      case 1:
        return "Athletics"
        case 2:
        return "Canoe"
        case 3:
        return "Cycling"
        case 4:
        return "Fencing"
        case 5:
        return "Judo"
        case 6:
        return "Rowing"
        case 7:
        return "Triathlon"
      default:
        return "Wrestling"
    }
  }

}

