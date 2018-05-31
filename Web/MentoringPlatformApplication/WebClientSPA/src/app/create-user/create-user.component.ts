import { Component, OnInit } from '@angular/core';
import { UserRole } from '../models/userRole.model';
import { User} from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  
  selectedValue = null;
  userRoles : UserRole[];
  user = new User();
  

  constructor(private userService : UserService) { }

  ngOnInit() {
    this.userService.getUserRoles().subscribe(
      userRoles => this.userRoles = userRoles);
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
    if (!user) { return; }
    this.userService.createUser(user)
      .subscribe(x => {
        console.log(x);
        this.resetForm(user);
      });
  }

}
