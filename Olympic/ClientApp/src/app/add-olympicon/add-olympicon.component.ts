import { Component, OnInit } from '@angular/core';
import { OlympicService } from '../olympic.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DetailedOlympicon } from '../models/detailedolympicon';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Country } from '../models/country';

@Component({
  selector: 'app-add-olympicon',
  templateUrl: './add-olympicon.component.html',
  styleUrls: ['./add-olympicon.component.css']
})
export class AddOlympiconComponent implements OnInit {

  public olympicon : DetailedOlympicon;

  public form: FormGroup;

  public countries: Country[];  

  public id: number;

  public sports: Array<string> = ["Archery", "Athletics",
    "Canoe",
    "Cycling",
    "Fencing",
    "Judo",
    "Rowing",
    "Triathlon",
    "Wrestling"];
  

  constructor(private avRoute: ActivatedRoute, private router: Router,
    private service : OlympicService,private formBuilder: FormBuilder) {
      this.form = this.formBuilder.group(
        {
          id : 0,
          surname: ['', [Validators.required]],
          forename: ['', [Validators.required]],
          birthday: ['',[Validators.required]],
          sport: ['',[Validators.required]],
          nationality: ['',[Validators.required]]
        }
      )

  }

  save() {  
  
    if (!this.form.valid) {  
        return;  
    }
    if (this.id>0) {  
      this.service.update(this.id,this.form.value).subscribe((data)=>{
        this.router.navigate(['']);     
      })
    }else{
      this.service.newOlympicon(this.form.value).subscribe((data) => this.router.navigate(['']));
    }
  }  

  get surname() { return this.form.get('surname'); }  
  get forename() { return this.form.get('forename'); } 
  get birthday() { return this.form.get('birthday'); } 
  get sport() { return this.form.get('sport'); } 
  get nationality() { return this.form.get('nationality'); } 

  ngOnInit() {
    this.id = this.avRoute.snapshot.params["id"];  
    if (this.id>0) {  
      this.service.getOlympicons(this.id).subscribe(result => {this.form.setValue(result);
      });
    }
    this.Get();
  }

  cancel() {
    this.router.navigate(['']);
  }

  Get() : void{
    this.service.getNations().subscribe(result=> {
      this.countries = result
    });

  }
}
