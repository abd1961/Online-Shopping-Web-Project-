export class Products{
    public productId: number;
    public productName : string;
    public price : number;
    public productDescription : string;
    public category : string;
    public productImgUrl : string;
}


export class MatchedProduct{
    public productId: number;
    public productName : string;
    public price : number;
    public isFavorite? : boolean;
    public description : string;
    public category : string;
    public productImgUrl : string;
}