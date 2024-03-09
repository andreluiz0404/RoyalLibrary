export interface Book {
    book_id: number;
    title: string;
    first_name: string;
    last_name: string;
    total_copies: number;
    copies_in_use: number;
    type?: string;
    isbn?: string;
    category?: string;
}