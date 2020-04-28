import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { AdventuresComponent } from './Game/adventures.component';
import { CharactersComponent } from './Game/characters.component';
import { AchievementsComponent } from './Game/achievements.component';
import { KJKPediaComponent } from './Game/kjkPedia.component';
import { DesignerComponent } from './Designer/designer.component';
import { FaqComponent } from './About/faq.component';
import { LoginComponent } from './About/login.component';
import { RegisterComponent } from './About/register.component';
import { ForgotPasswordComponent } from './About/forgotPassword.component';
import { AboutComponent } from './About/about.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdventuresComponent,
    CharactersComponent,
    AchievementsComponent,
    KJKPediaComponent,
    DesignerComponent,
    FaqComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
    NgbModalModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'Home', component: HomeComponent},
      { path: 'Adventures', component: AdventuresComponent },
      { path: 'Characters', component: CharactersComponent },
      { path: 'Achivements', component: AchievementsComponent },
      { path: 'KJKPedia', component: KJKPediaComponent },
      { path: 'Designer', component: DesignerComponent },
      { path: 'FAQ', component: FaqComponent },
      { path: 'About', component: AboutComponent },
      { path: '', redirectTo: "Home", pathMatch:'full' },
      { path: '**', redirectTo: "Home", pathMatch:'full' }
    ])
  ],
  providers: [],
  entryComponents:[RegisterComponent,ForgotPasswordComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
