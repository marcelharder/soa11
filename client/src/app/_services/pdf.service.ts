import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from './alertify.service';
import { environment } from '../../environments/environment';
import { AuthService } from './auth.service';
import { Article } from '../_models/Article';

@Injectable({
  providedIn: 'root'
})
export class PdfService {

baseUrl = environment.apiUrl;
constructor(private http: HttpClient, private alertify: ToastrService, private auth: AuthService) { }

getArticles() {
  return this.http.get<Article[]>(this.baseUrl + 'article');
}

getSpecificArticle(id) {
  return this.http.get<Article>(this.baseUrl + 'article/' + id);
}

addNewArticle(id: number, inv: Article) {
  return this.http.post<Article>(this.baseUrl + 'article/' + id, inv);
}

updateArticle(id: number, inv: Article) {
  return this.http.put<Article>(this.baseUrl + 'article/' + id, inv);
}




}
