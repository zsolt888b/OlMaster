import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Olympicon } from '../models/olympicon';
import { OlympicService } from '../olympic.service';
import { DetailedOlympicon } from '../models/detailedolympicon';

@Component({
  selector: 'app-olympicon',
  templateUrl: './olympicon.component.html',
  styleUrls: ['./olympicon.component.css']
})
export class OlympiconComponent implements OnInit {

  public olympicon: DetailedOlympicon;

  
  constructor( private _avRoute: ActivatedRoute,
    private service : OlympicService, private router : Router) {
  }

  ngOnInit() {
    if (this._avRoute.snapshot.params["id"]) {  
      this.service.getOlympicons((this._avRoute.snapshot.params["id"])).subscribe(result => {this.olympicon = result
      });
    }
  }

  back() {
    this.router.navigate(['']);
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

