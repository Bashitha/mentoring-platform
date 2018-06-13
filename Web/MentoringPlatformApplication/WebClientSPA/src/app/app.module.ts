import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule} from '@angular/common/http';
import { appRoutes } from './routes';
import { RouterModule } from '@angular/router';

import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { UserService } from './services/user.service';
import { ErrorService } from './services/error.service';
import { BaseUrlService } from './services/base-url.service';
import { CreateUserRoleComponent } from './create-user-role/create-user-role.component';
import { UserRoleService } from './services/user-role.service';


@NgModule({
  declarations: [
    AppComponent,
    CreateUserComponent,
    CreateUserRoleComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,    
    RouterModule.forRoot(appRoutes),  
  ],
  providers: [UserService, ErrorService, BaseUrlService, UserRoleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
