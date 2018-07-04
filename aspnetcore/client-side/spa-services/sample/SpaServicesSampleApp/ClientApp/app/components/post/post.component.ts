import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'post',
    templateUrl: './post.component.html'
})
export class PostComponent {
    public posts: Post[];

    constructor(private route: ActivatedRoute, private location: Location, private http: Http) {
        this.route.params
            .switchMap((params: Params) => http.get('/api/blogs/' + params['id'] + '/posts'))
            .subscribe(result => this.posts = result.json() as Post[]);
    }
}

interface Post {
    postId: number;
    title: string;
    author: string;
    link: string;
}