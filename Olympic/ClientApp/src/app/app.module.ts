import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { OlympiconComponent } from './olympicon/olympicon.component';
import { OlympicService } from './olympic.service';
import { AddOlympiconComponent } from './add-olympicon/add-olympicon.component';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
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
      { path: 'olympicon/:id', component: OlympiconComponent },
      { path:'edit-olympicon/:id', component: AddOlympiconComponent},
      { path: 'add-olympicon', component: AddOlympiconComponent }
    ])
  ],
  providers: [
    OlympicService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
