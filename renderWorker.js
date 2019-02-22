const arrayChunkSize = 1000;

importScripts('luxon.js');

let inputList = [];

addEventListener('message', event => {
    switch (event.data.command) {
        case 'clear':
            inputList = [];
            break;
        case 'append':
            inputList = inputList.concat(JSON.parse(event.data.list));
            break;
        case 'render':
            renderResultList(inputList, event.data);
            self.postMessage({
                command: 'continue'
            });
            break;
        case 'stop':
            self.postMessage({
                command: 'end'
            });
            self.close();
            break;
    }
});

function formatTime(isoString, timeFormat) {
    switch (timeFormat) {
        case '**blank**':
            return '';
        case '**original**':
            return isoString;
        default:
            return luxon.DateTime.fromISO(isoString, {setZone: true}).toFormat(timeFormat);
    }
}

function renderResultList(list, options) {
    let results = list.map(item => ({
        formattedTime: formatTime(item[1], options.timeFormat)
    }));

    for (let i = 0; i < results.length + arrayChunkSize; i += arrayChunkSize) {
        self.postMessage({
            command: 'append',
            list: JSON.stringify(results.slice(i, i + arrayChunkSize))
        });
    }
}