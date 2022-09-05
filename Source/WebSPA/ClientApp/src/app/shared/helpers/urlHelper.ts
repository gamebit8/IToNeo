export class UrlHelper {
    constructor(){ }

    public RequestUrl(baseUrl: string, id: number | string): string {
        return baseUrl + `/${id}`;
    }
}
