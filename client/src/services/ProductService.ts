
import type { ProductDto } from '../models/ProductDto';

export class ProductService {
	static async fetchProducts(url: string, sortAscending: boolean = true, filter: boolean): Promise<ProductDto[]> {
		try {
			var searchParams = new URLSearchParams()
			searchParams.append('sortBy', 'price')
			if (filter) {
				searchParams.append('maxPrice', '2')
			}
			searchParams.append('sortDescending', sortAscending ? 'false' : 'true')

			const requestUrl = url + "?" + searchParams.toString()
			const response = await fetch(requestUrl.toString())

			if (!response.ok) {
				throw new Error(`Failed to fetch products: ${response.statusText}`)
			}

			const data: ProductDto[] = await response.json()

			return data
		} catch (error) {
			console.error('Error fetching products:', error)
			throw error
		}
	}
}