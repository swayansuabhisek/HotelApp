import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItems } from 'src/app/Models/menu-items';
import { MenuitemService } from 'src/app/Service/menuitem.service';

@Component({
  selector: 'app-manuitem',
  templateUrl: './manuitem.component.html',
  styleUrls: ['./manuitem.component.css']
})
export class ManuitemComponent implements OnInit {
  menulist: MenuItems[] = [];
  
  constructor(private service :MenuitemService, private router : Router){
    
  }
  ngOnInit(): void {
    this.service.getAllDishes().subscribe((data : MenuItems[])=>{
      this.menulist = data
    });
  }

}
