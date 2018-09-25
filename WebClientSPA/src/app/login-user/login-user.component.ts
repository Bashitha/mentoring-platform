import { Component, OnInit } from '@angular/core';
import { User} from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {

  title = "Login";
  user = new User();

  constructor(private userService : UserService) { }

  ngOnInit() {
  }
  resetForm(user?)
  {
    this.user = {      
      userId : null,
      email : '',
      password : '',
      firstName : '',
      lastName : '',
      description : '',
      designation : '',
      userRoleId : null
    }
  }      
  onSubmit(user: User): void {
    console.log(user);
    if (!user) { return; }
    this.userService.loginUser(user)
      .subscribe(x => {
        console.log(x);
        this.resetForm(user);
      });
  }


}
