class Book {
    #title;
    #author;
    #year;
    #isIssued;

    constructor(title, author, year) {
        this.#title = title;
        this.#author = author;
        this.#year = year;
        this.#isIssued = false;
    }

    get title() {
        return this.#title;
    }

    get author() {
        return this.#author;
    }

    get year() {
        return this.#year;
    }

    get isIssued() {
        return this.#isIssued;
    }

    set isIssued(value) {
        if (typeof value === 'boolean') {
            this.#isIssued = value;
        } else {
            throw new Error('isIssued должно быть boolean');
        }
    }

    toggleIssue() {
        this.#isIssued = !this.#isIssued;
    }
}

class EBook extends Book {
    #fileSize;
    #format;

    constructor(title, author, year, fileSize, format) {
        super(title, author, year);
        this.#fileSize = fileSize;
        this.#format = format;
    }

    get fileSize() {
        return this.#fileSize;
    }

    get format() {
        return this.#format;
    }

    toggleIssue() {
        console.log("Электронные книги всегда доступны.");
    }
}

class Library {
    constructor() {
        this.books = [];
    }

    addBook(book) {
        this.books.push(book);
    }

    findBook(...args) {
        if (args.length === 1) {
            const title = args[0];
            const book = this.books.find(b => b.title === title);
            if (!book) throw new Error('Книга не найдена');
            return book;
        } else if (args.length === 2) {
            const [author, year] = args;
            const book = this.books.find(b => b.author === author && b.year === year);
            if (!book) throw new Error('Книга не найдена');
            return book;
        } else {
            throw new Error('Неверное количество аргументов');
        }
    }

    listAllBooks() {
        this.books.forEach(book => {
            console.log(`Название: ${book.title}, Автор: ${book.author}, Статус: ${book.isIssued ? 'Выдана' : 'Доступна'}`);
        });
    }
}

const library = new Library();
const book1 = new Book('1984', 'Джордж Орэлл', 1949);
const ebook1 = new EBook('Собачье сердце', 'Михаил Булгаков', 1925, 2, 'epub');

library.addBook(book1);
library.addBook(ebook1);

library.listAllBooks();

try {
    const foundBook = library.findBook('1984');
    console.log(`Найдена книга: ${foundBook.title}`);
} catch (error) {
    console.error(error.message);
}
