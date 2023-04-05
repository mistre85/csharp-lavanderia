# Csharp-lavanderia

## Obbiettivo
Realizzare un programma console in c# per la verifica remota del funzionamento delle lavatrici e delle asciugatrici presenti in una lavanderia self-service.

## Descrizione generale
La lavanderia possiede 3 lavatrici e 2 asciugatrici.
Le lavatrici hanno due serbatoi integrati, uno di detersivo e uno di ammorbidente.
Il serbatoio di detersivo ha una capacità di 1000ml mentre quello dell’ammorbidente di 500ml. 

### Programmi delle lavatrici
| Numero | Nome | Durata (minuti) | Gettoni | Consumo ammorbidente (ml) | Consumo detersivo (ml) |
| --- | --- | --- | --- | --- | --- |
| 1 | Rinfrescante | 20 | 5 | 20 | 25 |
| 2 | Rinnovante | 40 | 10 | 40 | 50 |
| 3 | Sgrassante | 60 | 15 | 60 | 100 |

### Programmi delle asciugatrici
| Numero | Nome | Durata (minuti) | Gettoni |
| --- | --- | --- | --- |
| 1 | Rapido | 20 | 2 |
| 2 | Intenso | 60 | 4 |

L’utente può agire tramite il programma per effettuare le seguenti verifiche:
- Aprire lo sportello
- Chiudere lo sportello
- Inserire i gettoni
- Chiedere la lista dei programmi
- Selezionare un programma
- Avviare il programma selezionato
- Fermare il programma in esecuzione
- Ricaricare detersivo e ammorbidente

Se una di queste operazioni non è logicamente possibile, il programma dovrà mandare un messaggio all’utente per evidenziare la problematica. 

## Linee guida e vincoli
Per la realizzazione si implementi il codice utilizzando il paradigma ad oggetti e identificando, se necessario, classi astratte ed eredità. Non è necessario l’utilizzo di interfacce.

Per l’interazione con l’utente si implementi il seguente comportamento nel `program.cs`:

Finché l’utente non decide di uscire:
- Stampa lo stato delle macchine in formato tabellare
- Mostra un messaggio informativo dell’ultima operazione effettuata. Questo messaggio può contenere sia gli errori che le operazioni andate a buon fine
- Mostra la lista dei comandi
- Attende l’inserimento del comando all’utente

### Lista comandi
| Comando | Descrizione | Parametro aggiuntivo |
| --- | --- | --- |
| apri | apre lo sportello | - |
| chiudi | chiude lo sportello | - |
| gettoni | inserisce il numero di gettoni nella macchina specificata | numero di gettoni. positivo e maggiore di 0 |
| lista | fornisce la lista dei programmi | - |
| programma | seleziona il programma specificato sulla mac
