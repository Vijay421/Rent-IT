// TODO: make all relevant functions static.
// TODO: call all relevant functions setOnX.
export class Fetcher {
    constructor(baseUrl = "", dryRun = false) {
        this.method = "GET";
        this.baseUrl = baseUrl;
        this.url = "";
        this.payload = null;
        this.dryRun = dryRun;

        this.onOk = undefined;
        this.onError = undefined;

        this.statusCode = undefined;
        this.onStatusCode = undefined;

        this.statusCodes = [];
        this.onStatusCodes = undefined;

        this.parseResponse = undefined;
    }

    get(url, payload) {
        this.url = url;
        this.payload = payload;
        this.method = "GET";

        return this;
    }

    post(url, payload) {
        this.url = url;
        this.payload = payload;
        this.method = "POST";

        return this;
    }

    put(url, payload) {
        this.url = url;
        this.payload = payload;
        this.method = "PUT";

        return this;
    }

    patch(url, payload) {
        this.url = url;
        this.payload = payload;
        this.method = "PATCH";

        return this;
    }

    delete(url, payload) {
        this.url = url;
        this.payload = payload;
        this.method = "DELETE";

        return this;
    }

    setOnResponseFailed(onResponseFailed) {
        this.onResponseFailed = onResponseFailed;

        return this;
    }

    setOnOkResponse(onOk) {
        this.onOk = onOk;

        return this;
    }

    setOnErrorResponse(onError) {
        this.onError = onError;

        return this;
    }

    onStatusCode(statusCode, onStatusCode) {
        this.statusCode = statusCode;
        this.onStatusCode = onStatusCode;
    }

    onStatusCodes(statusCodes, onStatusCodes) {
        this.statusCodes = statusCodes;
        this.onStatusCodes = onStatusCodes;
    }

    setParseJson(parseResponse) {
        this.parseResponse = parseResponse;
    }

    setParseText(parseResponse) {
        this.parseResponse = parseResponse;
    }

    setOnParseError(onParseError) {
        this.onParseError = onParseError;
    }

    async fetch() {
        const request = {
            method: this.method,

            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: this.payload && JSON.stringify(this.payload),
        };

        console.log(`Calling: ${this.baseUrl}${this.url}`);

        if (this.dryRun) {
            return;
        }

        try {
            const response = await fetch(`${baseUrl}${this.url}`, request);

            if (response.ok) {
                let parsedResponse;
                if (this.parseResponse) {
                    try {
                        parsedRespons = this.parseResponse(response);
                    } catch(error) {
                        if (this.onParseError) {
                            this.onParseError(error);
                        }
                    }
    
                    this.onOkResponse(parsedResponse, response.status);
                }
    
            } else {
                this.onErrorResponse();
            }
        } catch (error) {

        }
    }
}

async function main() {
    const baseUrl = "https://nl.wikipedia.org/";

    await new Fetcher(baseUrl, true)
        .get("wiki/Hoofdpagina")
        .fetch();

    await new Fetcher(baseUrl, true)
        .get("wiki")
        .fetch();
}

main();
