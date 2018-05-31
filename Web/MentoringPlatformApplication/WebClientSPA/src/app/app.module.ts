import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule} from '@angular/common/http';


import { AppComponent } from './app.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { UserService } from './services/user.service';
import { ErrorService } from './services/error.service';
import { BaseUrlService } from './services/base-url.service';


@NgModule({
  declarations: [
    AppComponent,
    CreateUserComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,    
  ],
  providers: [UserService, ErrorService, BaseUrlService],
  bootstrap: [AppComponent]
})
export class AppModule { }
