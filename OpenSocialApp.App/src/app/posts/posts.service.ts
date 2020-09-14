import { Injectable } from '@angular/core'
import { Post, PostType } from './post';
import { Guid } from 'guid-typescript';
import { Subject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})
export class PostsService {
    private posts: Post[] = [];
    private postsUpdatedSubs$ = new Subject<Post[]>();
    private apiUri = "http://localhost:80/api";

    constructor(private http: HttpClient) { }

    getPostsUpdatedListener(): Observable<Post[]> {
        return this.postsUpdatedSubs$.asObservable();
    }

    getPosts(): Observable<Post[]> {
        return this.http.get<Post[]>(`${this.apiUri}/posts`).pipe(map((res: Post[]) => {
            this.posts = [...res];
            this.postsUpdatedSubs$.next(this.posts);
            return res;
        }));
    }

    getPost(id: string): Observable<Post> {
        return this.http.get<Post>(`${this.apiUri}/posts/${id}`);
    }

    createPost(status: string): Observable<Post> {
        let post = {
            text: status,
            type: PostType.Status,
            assetUrl: null,
            postedBy: Guid.create().toString()
        };

        return this.http.post<Post>(`${this.apiUri}/posts`, post).pipe(map((res) => {
            this.posts.push(res);
            this.postsUpdatedSubs$.next(this.posts);
            return res;
        }));
    }
}