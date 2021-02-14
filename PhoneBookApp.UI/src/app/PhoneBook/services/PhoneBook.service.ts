import { Injectable, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
@NgModule({
  providers:[]
})
export class PhoneBookService {

  constructor(private http: HttpClient) { }

   getAll(): Observable<any> {
     return this.http.get(environment.apiUrl + 'api/PhoneBook/getall');
  }

  getAllEntries(id): Observable<any> {
    return this.http.get(environment.apiUrl + 'api/Entry/getall?phoneBookId='+id);
 }

 create(entry:any): Observable<any>{
   return this.http.post(environment.apiUrl+'api/Entry/add', entry);
 }
}
