How to use program:
1. Starta applikation och skriv in nummer du vill verifera. 
2. Applikationen kommer kontrollera nummer och ge dig ett svar hurvida nummer är godkänt eller ej. Samt identifiera om nummer tillhör
Personummer-kategori, Samordnignsnummer-kategori eller Organisationsnummer-kategori. Vid ej godkänt nummer skapas en logfil över nummret
som dessutom datummärks.

Övrig info:

Program är testat mot giltiga och ogiltiga personnummer
Program är testat mot giltiga samordningsnummer
Program är testat mot giltiga orgnr
Program är testat mot felaktiga nummer
Program specificerar för användaren vilken typ av nummer som fyllts i
Program kan hantera felinmatningar av användare till viss del och tar bort otilåtna tecken samt kontrollerar att sträng innehåller minst
10st tecken.
Tester har utförts på samtliga programmets metoder
Byggskript: build.cake
Testdata som levererats i programmeringsuppgiften har använts som test mot applikation.
Dock innehöll test-nummren vad jag kunde se ett fel, då nr: 190302299813 står i beskrivning att det ska vara ett ogiltigt nr men 
är enligt Luhns algoritm giltig nr.