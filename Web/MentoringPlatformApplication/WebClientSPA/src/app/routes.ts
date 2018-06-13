import { Routes } from '@angular/router'
import { CreateUserComponent } from './create-user/create-user.component';
import { CreateUserRoleComponent } from './create-user-role/create-user-role.component';


export const appRoutes : Routes = [   
    
    {path : 'createUserRole', component: CreateUserRoleComponent},
    {path : 'createUser', component: CreateUserComponent},
    {path : '**', component: CreateUserComponent},
]