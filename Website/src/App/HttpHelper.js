
const BaseUrl = 'http://localhost';
//const BaseUrl = 'http://ec2-13-238-219-247.ap-southeast-2.compute.amazonaws.com'
const BasePort = 8080;

/**
 * Get method
 */
export async function Get(url) {

    const Url = `${BaseUrl}:${BasePort}/${url}`;

    const res = await fetch(Url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    let status = res.status;
    let body = status !== 500 ? await res.json() : null;

    return { status, body };
};

/**
 * Post method
 */
export async function Post(url, newData) {

    const Url = `${BaseUrl}:${BasePort}/${url}`;

    const res = await fetch(Url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newData)
    });
    let status = res.status;

    let body = status !== 500 ? await res.json() : null;

    return { status, body };
}




