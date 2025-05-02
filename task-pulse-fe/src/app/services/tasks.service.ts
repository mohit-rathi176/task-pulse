import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment as ENV } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Task } from '../models/task.model';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = ENV.baseApiUrl;

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.baseUrl}/tasks`);
  }

  addTask(task: any): Observable<Task> {
    return this.http.post<Task>(`${this.baseUrl}/tasks`, task);
  }
}
