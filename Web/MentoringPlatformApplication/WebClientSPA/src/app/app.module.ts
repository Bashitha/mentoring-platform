import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
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
import {MatButtonModule, MatCheckboxModule,MatGridListModule,MatInputModule,MatIconModule,MatTabsModule,MatOptionModule,MatSelectModule} from '@angular/material';
import { LoginUserComponent } from './login-user/login-user.component';


@NgModule({
  declarations: [
    AppComponent,
    CreateUserComponent,
    CreateUserRoleComponent,
    LoginUserComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,    
    RouterModule.forRoot(appRoutes),
    MatButtonModule,  
    MatCheckboxModule,
    MatGridListModule,
    MatInputModule,
    MatIconModule,
    MatTabsModule,
    MatOptionModule,
    MatSelectModule
  ],
  providers: [UserService, ErrorService, BaseUrlService, UserRoleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
