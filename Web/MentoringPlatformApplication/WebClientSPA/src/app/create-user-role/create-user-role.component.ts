import { Component, OnInit } from '@angular/core';
import { UserRole } from '../models/userRole.model';
import { UserService } from '../services/user.service';
import { UserRoleService } from '../services/user-role.service';

@Component({
  selector: 'app-create-user-role',
  templateUrl: './create-user-role.component.html',
  styleUrls: ['./create-user-role.component.css']
})
export class CreateUserRoleComponent implements OnInit {

  constructor(private userRoleService: UserRoleService) { }

  userRole= new UserRole();

  ngOnInit() {
  }

  onAdd(userRole: UserRole): void {
    if (!userRole) { return; }
    this.userRoleService.createUserRole(userRole)
      .subscribe(userRole => {
        console.log(userRole);
      });
  }

}
