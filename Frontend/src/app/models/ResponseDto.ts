import { BaseModelDto } from "./BaseModelDto";

export class ResponseDto extends BaseModelDto {
    public object: Object = [];
    public ErrorOccurred: boolean;
    public errors: Array<Object> = [];
}