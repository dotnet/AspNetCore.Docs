import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'blog',
    templateUrl: './blog.component.html'
})
export class BlogComponent {
    public blogs: Blog[];

    constructor(http: Http) {
        http.get('/api/blogs').subscribe(result => {
            this.blogs = result.json() as Blog[];
        });
    }
}

interface Blog {
    blogId: number;
    title: string;
    url: string;
}