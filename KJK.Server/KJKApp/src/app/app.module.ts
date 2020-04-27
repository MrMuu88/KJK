import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
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
    AboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
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
      { path: 'Login', component: LoginComponent },
      { path: 'Register', component: RegisterComponent },
      { path: 'About', component: AboutComponent },
      { path: '', redirectTo: "home", pathMatch:'full' },
      { path: '**', redirectTo: "home", pathMatch:'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
