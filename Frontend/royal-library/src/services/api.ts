import axios, { AxiosInstance, AxiosResponse } from 'axios';
import { Book } from './Book';

export class ApiClient {
    private apiClient: AxiosInstance;

    constructor() {
        this.apiClient = axios.create({ baseURL: process.env.NEXT_PUBLIC_API_URL });
    }

    private async executeGet<T>(resource: string): Promise<T> {
        const response: AxiosResponse = await this.apiClient.get(resource);
        return response.data as T;
    }

    public async getBooks(searchType: string, searchTerm: string): Promise<Book[]> {
        const resource: string = `/book/?searchType=${searchType}&searchTerm=${searchTerm}`;
        return this.executeGet<Book[]>(resource);
    }
}