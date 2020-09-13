export class Post {
    id: string;
    text: string;
    type: PostType;
    assetUrl: string;
    postedOn: Date;
    postedBy: string;
}

export enum PostType {
    Status,
    Image,
    Video
};