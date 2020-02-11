import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { OlympiconComponent } from './olympicon/olympicon.component';
import { OlympicService } from './olympic.service';
import { AddOlympiconComponent } from './add-olympicon/add-olympicon.component';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    OlympiconComponent,
    AddOlympiconComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    BrowserModule /* or CommonModule */, 
      FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'olympicon/:id', component: OlympiconComponent },
      { path:'edit-olympicon/:id', component: AddOlympiconComponent},
      { path: 'add-olympicon', component: AddOlympiconComponent },
      { path: 'search/:q/:w/:r', component: AddOlympiconComponent }
    ])
  ],
  providers: [
    OlympicService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
