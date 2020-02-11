import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
    this.service.search(this.form.value).subscribe(result =>{
      //this.nations = result;
    })
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

