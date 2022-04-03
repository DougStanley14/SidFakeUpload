import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  //private baseUrl = 'http://localhost:5198/api';
  private baseUrl = 'https://localhost:7072/api';

  constructor(private http: HttpClient) { }

  upload(file: File): Observable<HttpEvent<any>> {
    console.log("Hit Upload")
    const formData: FormData = new FormData();

    //const outfiles = [file];

    formData.append('file', file);

    console.log("Form Data", formData)

    const req = new HttpRequest('POST', `${this.baseUrl}/NDDSFiles`, formData, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }

  getFiles(): Observable<any> {
    return this.http.get(`${this.baseUrl}/NDDSFiles`);
  }
}
