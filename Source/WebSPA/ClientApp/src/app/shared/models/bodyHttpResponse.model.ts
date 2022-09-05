import { Hateoas } from "./hateoas.model";

export interface BodyHttpResponse<TD> {
    data: TD
    link: Hateoas[]
}
