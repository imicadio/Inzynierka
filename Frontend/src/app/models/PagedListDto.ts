export class PagedListDto<T> {    
    totalPageCount: number;
    object: T;
    currentPage: number;   
    count: number;     
}