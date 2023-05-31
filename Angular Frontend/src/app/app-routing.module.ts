import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManuitemComponent } from './Components/manuitem/manuitem.component';



const routes: Routes = [
  {path:'', redirectTo:'menulist', pathMatch:'full',},
  {path:'menulist', component:ManuitemComponent}
  // {path:'employees/view/:id', component:ViewEmpComponent},
  // {path:'employees/edit/:id', component:EditEmpComponent},
  // {path:'employees/addNew', component:AddEmpComponent},
  // {path:'employees/Validation', component:TemplateComponent},
  // {path:'employees/Reactive', component:ReactiveFormsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
