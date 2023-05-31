import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { MenuItems } from '../Models/menu-items';


@Injectable({
  providedIn: 'root'
})
export class MenuitemService {

  url :string = "http://localhost:5048/Menu";
   
  constructor(private http:HttpClient) { }

  getAllDishes():Observable<MenuItems[]>{
    return this.http.get<MenuItems[]>(this.url)
  }

  findDish(dishId : number):Observable<MenuItems>{
    let tempUrl = this.url + "/"+ dishId;
    return this.http.get<MenuItems>(tempUrl);
  }

  public addDish(emp : MenuItems) :Observable<MenuItems>{
    return this.http.post<MenuItems>(this.url, emp);
  }

  public deleteDish(dishId : number) :Observable<string>{
    let tempUrl = this.url + "/"+ dishId;
    return this.http.delete<string>(tempUrl);
  }

  public updateDish(emp :MenuItems):Observable<MenuItems>{
    const tempUrl = this.url + "/"+ emp.dishId;
    return this.http.put<MenuItems>(tempUrl, emp);
  }

}
