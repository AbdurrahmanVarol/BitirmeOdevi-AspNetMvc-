
let noemalOranlar = {
    sgkIsciPayiOranı: 0.14,
    sgkIssizlikIsciPayiOranı: 0.01,
    sgkIsverenPayiOranı: 0.155,
    sgkIssizlikIsverenPayiOranı: 0.02,
    damgaVergisi: 0.00759
}
let emekliOranlar = {
    sgkIsciPayiOranı: 0.075,
    sgkIssizlikIsciPayiOranı: 0,
    sgkIsverenPayiOranı: 0.155,
    sgkIssizlikIsverenPayiOranı: 0.02,
    damgaVergisi: 0.00759
}

function kapat() {
    document.getElementById("sonuc").hidden = true
}

function Hesapla() {
    if (document.getElementById("sonuc").hidden = true)
        document.getElementById("sonuc").hidden = false
    let aylar = ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık",]

    let kisiler = []
    let Oranlar = {}
    let sigortaDurum = parseInt(document.getElementById("sigortaDurum").value)
    if (sigortaDurum == 1)
        Oranlar = noemalOranlar
    else
        Oranlar = emekliOranlar

    let toplamMaas = 0
    let sakatlikDerece = parseInt(document.getElementById("sakatlikDurum").value)
    let vergiIndirimi = SakatlikBul(sakatlikDerece)
    // hesaplamaSekli id li sectionun değeri brütten nete ise value si 1 netten brüte ise valuesi 2 olur
    let hesaplamaSekli = document.getElementById("hesaplamaSekli").value
    if (hesaplamaSekli == 1) {
        aylar.forEach(ay => {
            let kisi = {
                ay: "",
                brütMaas: 0,
                sgkIsciPayi: 0,
                sgkIssizlikIsciPayi: 0,
                damgaVergisi: 0,
                gelirVergisi: 0,
                vergiDilim: 0,
                netTutar: 0,
                agi: 0,
                odenecekTutar: 0,
                sigortaVeİssizlikPayı: 0
            }
            kisi.agi = AgiBul()

            kisi.brütMaas = parseInt(document.getElementById("maas").value)
            toplamMaas += kisi.brütMaas
            kisi.ay = ay
            gelirVergisi = VergiBul(toplamMaas)
            kisi = BrüttenNete(kisi, gelirVergisi, vergiIndirimi, Oranlar)
            kisiler.push(kisi)
        })

        listele(kisiler)

    }

    else
    {
        aylar.forEach(ay => {
            let kisi = {
                ay: "",
                brütMaas: 0,
                sgkIsciPayi: 0,
                sgkIssizlikIsciPayi: 0,
                damgaVergisi: 0,
                gelirVergisi: 0,
                vergiDilim: 0,
                netTutar: 0,
                agi: 0,
                odenecekTutar: 0,
                sigortaVeİssizlikPayı: 0
            }
            kisi.agi = AgiBul()

            kisi.netTutar = parseInt(document.getElementById("maas").value)
            toplamMaas += kisi.netTutar
            kisi.ay = ay
            gelirVergisi = VergiBul(toplamMaas)
            kisi = NettenBrüte(kisi, gelirVergisi, vergiIndirimi, Oranlar)
            kisiler.push(kisi)
        })

        listele(kisiler)
    }
        
}

function AgiBul() {
    let agi = 0
    let medeniDurum = document.getElementById("medeniDurum").value
    let cocukSayisi = parseInt(document.getElementById("cocukSayisi").value)
    //Bekar agi oranı
    if (medeniDurum == 1)
        agi = 268.31
    //evli esi çalışan agi oranları
    else if (medeniDurum == 2) {

        switch (cocukSayisi) {
            case 0:
                agi = 268.31
                break
            case 1:
                agi = 308.56
                break
            case 2:
                agi = 348.81
                break
            case 3:
                agi = 402.47
                break
            case 4:
                agi = 429.30
                break
            default:
                agi = 456.13
        }
    }
    //evli esi calışmayan agi oranları
    else if (medeniDurum == 3) {

        switch (cocukSayisi) {
            case 0:
                agi = 321.98
                break
            case 1:
                agi = 362.22
                break
            case 2:
                agi = 402.47
                break
            case 3:
                agi = 456.13
                break
            case 4:
                agi = 456.13
                break
            default:
                agi = 456.13
        }
    }
    //agi den faydalanmayacak
    else
        agi = 0

    return agi
}

function VergiBul(maas) {
    // maas aralıklarına göre gelir vergisi oranını buluyor
    let vergi
    if (maas >= 0 && maas < 24000)
        vergi = 0.15
    else if (maas >= 24000 && maas < 53000)
        vergi = 0.20
    else if (maas >= 53000 && maas < 130000)
        vergi = 0.27
    else if (maas >= 130000 && maas < 650000)
        vergi = 0.35
    else if (maas >= 650000)
        vergi = 0.40

    return vergi
}

function SakatlikBul(sakatlikDerece) {

    let vergiIndirimi
    if (sakatlikDerece == 1)
        vergiIndirimi = 1500
    else if (sakatlikDerece == 2)
        vergiIndirimi = 860
    else if (sakatlikDerece == 3)
        vergiIndirimi= 380
    else
        vergiIndirimi = 0

    return vergiIndirimi
}

function BrüttenNete(kisiParametre, gelirVergisi, vergiIndirimi, Oranlar) {
    let kisi = {
        ay: "",
        brütMaas: 0,
        sgkIsciPayi: 0,
        sgkIssizlikIsciPayi: 0,
        damgaVergisi: 0,
        gelirVergisi: 0,
        vergiDilim: 0,
        netTutar: 0,
        agi: 0,
        odenecekTutar: 0,
        sigortaVeİssizlikPayı: 0
    }
    kisi = kisiParametre
    let gelirVergisiMatrahi
    let vergiKesintisi
    let kesintiToplam
    let netUcret
    let isverenMaaliyet
    let indirimSonrasiGelirVergisiMahrahi
    let aylikGelirVergisi
    let odenecekTutar
    let sgkIsciPayi = kisi.brütMaas * Oranlar.sgkIsciPayiOranı;
    let sgkIssizlikIsciPayi = kisi.brütMaas * Oranlar.sgkIssizlikIsciPayiOranı;
    gelirVergisiMatrahi = kisi.brütMaas - sgkIsciPayi - sgkIssizlikIsciPayi;

    indirimSonrasiGelirVergisiMahrahi = gelirVergisiMatrahi - vergiIndirimi;
    //vergi kesintisi = gelir vergisi matrahı x gelir vergisi oranı + brüt maaş x damga vergisi
    aylikGelirVergisi = indirimSonrasiGelirVergisiMahrahi * gelirVergisi;

    vergiKesintisi = aylikGelirVergisi + kisi.brütMaas * Oranlar.damgaVergisi;

    kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;

    netUcret = kisi.brütMaas - kesintiToplam;

    if (kisi.agi > aylikGelirVergisi)
        odenecekTutar = netUcret + aylikGelirVergisi;
    else
        odenecekTutar = netUcret + kisi.agi;

    // Eğer engelli birisini çalıştırıyorsa işveren maaliyetleri devlet tarafından karşılanır
    if (vergiIndirimi != 0)
        isverenMaaliyet = 0;
    else
        isverenMaaliyet = kisi.brütMaas + kisi.brütMaas * Oranlar.sgkIsverenPayiOranı + kisi.brütMaas * Oranlar.sgkIssizlikIsverenPayiOranı; 

    kisi.sgkIsciPayi = sgkIsciPayi.toFixed(2)
    kisi.sgkIssizlikIsciPayi = sgkIssizlikIsciPayi.toFixed(2)
    kisi.damgaVergisi = (gelirVergisiMatrahi * Oranlar.damgaVergisi).toFixed(2)
    kisi.gelirVergisi = (gelirVergisiMatrahi * gelirVergisi).toFixed(2)
    kisi.vergiDilim = parseInt(gelirVergisi * 100);
    kisi.netTutar = netUcret.toFixed(2)
    kisi.odenecekTutar = odenecekTutar.toFixed(2)
    kisi.sigortaVeİssizlikPayı = isverenMaaliyet.toFixed(2)
    return kisi
}
function NettenBrüte(kisiParametre, gelirVergisi, vergiIndirimi, Oranlar) {
    let kisi = {
        ay: "",
        brütMaas: 0,
        sgkIsciPayi: 0,
        sgkIssizlikIsciPayi: 0,
        damgaVergisi: 0,
        gelirVergisi: 0,
        vergiDilim: 0,
        netTutar: 0,
        agi: 0,
        odenecekTutar: 0,
        sigortaVeİssizlikPayı: 0
    }
    kisi = kisiParametre
    if (gelirVergisi == 0.15)
        kisi.brütMaas = kisi.netTutar * 1.3989;
    else if (gelirVergisi == 0.2) {
        kisi.brütMaas = kisi.netTutar * 1.3989;
        kisi.brütMaas += kisi.brütMaas * 0.06315;
    }
    else if (gelirVergisi == 0.27) {
        kisi.brütMaas = kisi.netTutar * 1.3989;
        kisi.brütMaas += kisi.brütMaas * 0.16635;
    }
    else if (gelirVergisi == 0.35) {
        kisi.brütMaas = kisi.netTutar * 1.3989;
        kisi.brütMaas += kisi.brütMaas * 0.3119;
    }
    else {
        kisi.brütMaas = kisi.netTutar * 1.3989;
        kisi.brütMaas += kisi.brütMaas * 0.42288;
    }
   
    let gelirVergisiMatrahi
    let vergiKesintisi
    let kesintiToplam
    let netUcret
    let isverenMaaliyet
    let indirimSonrasiGelirVergisiMahrahi
    let aylikGelirVergisi
    let odenecekTutar
    let sgkIsciPayi = kisi.brütMaas * Oranlar.sgkIsciPayiOranı;
    let sgkIssizlikIsciPayi = kisi.brütMaas * Oranlar.sgkIssizlikIsciPayiOranı;
    gelirVergisiMatrahi = kisi.brütMaas - sgkIsciPayi - sgkIssizlikIsciPayi;

    indirimSonrasiGelirVergisiMahrahi = gelirVergisiMatrahi - vergiIndirimi;
    //vergi kesintisi = gelir vergisi matrahı x gelir vergisi oranı + brüt maaş x damga vergisi
    aylikGelirVergisi = indirimSonrasiGelirVergisiMahrahi * gelirVergisi;

    vergiKesintisi = aylikGelirVergisi + kisi.brütMaas * Oranlar.damgaVergisi;

    kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;

    netUcret = kisi.brütMaas - kesintiToplam;

    if (kisi.agi > aylikGelirVergisi)
        odenecekTutar = netUcret + aylikGelirVergisi;
    else
        odenecekTutar = netUcret + kisi.agi;

    // Eğer engelli birisini çalıştırıyorsa işveren maaliyetleri devlet tarafından karşılanır
    if (vergiIndirimi != 0)
        isverenMaaliyet = 0;
    else
        isverenMaaliyet = kisi.brütMaas + kisi.brütMaas * Oranlar.sgkIsverenPayiOranı + kisi.brütMaas * Oranlar.sgkIssizlikIsverenPayiOranı;

    kisi.sgkIsciPayi = sgkIsciPayi.toFixed(2)
    kisi.sgkIssizlikIsciPayi = sgkIssizlikIsciPayi.toFixed(2)
    kisi.damgaVergisi = (gelirVergisiMatrahi * Oranlar.damgaVergisi).toFixed(2)
    kisi.gelirVergisi = (gelirVergisiMatrahi * gelirVergisi).toFixed(2)
    kisi.vergiDilim = parseInt(gelirVergisi * 100);
    kisi.netTutar = netUcret.toFixed(2)
    kisi.odenecekTutar = odenecekTutar.toFixed(2)
    kisi.sigortaVeİssizlikPayı = isverenMaaliyet.toFixed(2)
    return kisi
}
function listele(kisilerParametre) {
    let kiailer = []
    kisiler = kisilerParametre
    let footer =
    {
        ortalamaBrüt: 0,
        ortalamaNet: 0,
        ortalamaOdenecek: 0,
        Brüt: 0,
        Net: 0,
        sgkIsciPayi: 0,
        sgkIssizlikIsciPayi: 0,
        damgaVergisi: 0,
        gelirVergisi: 0,
        agi: 0,
        odenecekTutar: 0,
        sigortaVeİssizlikPayı:0
    }
    let html = ``
    let htmlOrtalama = ``
    let htmlToplam = ``
    let element
    let element2

    kisiler.forEach(kisi => {
        footer.Brüt += kisi.brütMaas
        footer.Net += parseFloat(kisi.netTutar)
        footer.sgkIsciPayi += parseFloat(kisi.sgkIsciPayi)
        footer.sgkIssizlikIsciPayi += parseFloat(kisi.sgkIssizlikIsciPayi)
        footer.damgaVergisi += parseFloat(kisi.damgaVergisi)
        footer.gelirVergisi += parseFloat(kisi.gelirVergisi)
        footer.agi += parseFloat(kisi.agi)
        footer.odenecekTutar += parseFloat(kisi.odenecekTutar)
        footer.sigortaVeİssizlikPayı += parseFloat(kisi.sigortaVeİssizlikPayı)
        html += ` <tr>
                  <td>${kisi.ay}</td>
                  <th>${kisi.brütMaas.toFixed(2)}</th>
                  <th>${kisi.sgkIsciPayi}</th>
                  <th>${kisi.sgkIssizlikIsciPayi}</th>
                  <th>${kisi.damgaVergisi}</th>
                  <th>${kisi.gelirVergisi}</th>
                  <th>${kisi.vergiDilim} %</th>
                  <th>${kisi.netTutar}</th>
                  <th>${kisi.agi}</th>
                  <th>${kisi.odenecekTutar}</th>
                  <th>${kisi.sigortaVeİssizlikPayı}</th>
                  </tr>
                `

    })
    element = document.getElementById("body")
    element.innerHTML = html

    footer.ortalamaNet = (footer.Net / 12).toFixed(2)
    footer.ortalamaBrüt = (footer.Brüt / 12).toFixed(2)
    footer.ortalamaOdenecek = (footer.odenecekTutar / 12).toFixed(2)
    htmlOrtalama = ` <tr>
                  <td>Aylık Ortalamalar</td>
                  <th>${footer.ortalamaBrüt}</th>
                  <th></th>
                  <th></th>
                  <th></th>
                  <th></th>
                  <th></th>
                  <th>${footer.ortalamaNet}</th>
                  <th></th>
                  <th>${footer.ortalamaOdenecek}</th>
                  <th></th>
                  </tr>
                `
    

    htmlToplam = `<tr>
                  <td>Toplam</td>
                  <th>${footer.Brüt.toFixed(2)}</th>
                  <th>${footer.sgkIsciPayi.toFixed(2)}</th>
                  <th>${footer.sgkIssizlikIsciPayi.toFixed(2)}</th>
                  <th>${footer.damgaVergisi.toFixed(2)}</th>
                  <th>${footer.gelirVergisi.toFixed(2)}</th>
                  <th></th>
                  <th>${footer.Net.toFixed(2)}</th>
                  <th>${footer.agi.toFixed(2)}</th>
                  <th>${footer.odenecekTutar.toFixed(2)}</th>
                  <th>${footer.sigortaVeİssizlikPayı.toFixed(2)}</th>
                  </tr>
                `
    element2 = document.getElementById("footer")
    element2.innerHTML = htmlOrtalama + htmlToplam
}