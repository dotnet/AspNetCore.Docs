// The following sample code uses TypeScript and must be compiled to JavaScript
// before a browser can execute it.
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/streamHub")
    .build();
document.getElementById("streamButton").addEventListener("click", (event) => __awaiter(this, void 0, void 0, function* () {
    try {
        connection.stream("Counter", 10, 500)
            .subscribe({
            next: (item) => {
                var li = document.createElement("li");
                li.textContent = item;
                document.getElementById("messagesList").appendChild(li);
            },
            complete: () => {
                var li = document.createElement("li");
                li.textContent = "Stream completed";
                document.getElementById("messagesList").appendChild(li);
            },
            error: (err) => {
                var li = document.createElement("li");
                li.textContent = err;
                document.getElementById("messagesList").appendChild(li);
            },
        });
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
}));
document.getElementById("uploadButton").addEventListener("click", (event) => __awaiter(this, void 0, void 0, function* () {
    const subject = new signalR.Subject();
    yield connection.send("UploadStream", subject);
    var iteration = 0;
    const intervalHandle = setInterval(() => {
        iteration++;
        subject.next(iteration.toString());
        if (iteration === 10) {
            clearInterval(intervalHandle);
            subject.complete();
        }
    }, 500);
    event.preventDefault();
}));
// We need an async function in order to use await, but we want this code to run immediately,
// so we use an "immediately-executed async function"
(() => __awaiter(this, void 0, void 0, function* () {
    try {
        yield connection.start();
    }
    catch (e) {
        console.error(e.toString());
    }
}))();
