PROJE AÇIKLAMALARI

    PROJEDE KULLANILAN TEKNOLOJİLER
    1-DOCKER
    2-MONGODB
    3-WEBAPİ

    Docker üzerindeki containları kullandığı için sadece dockerı kurup, docker-compose'u set as startup project olarak başlatmanız yeterlidir. Docker size containları oluşturacaktır.
Docker containları görmek için docker ps yazmalısınız. Projeyi çalıştırdığınızda, ilk sayfa olarak swagger gelmesi gerekmektedir. Gelmediği takdirde, docker ps'den localhost yolunuzu
bakınız, sonra docker-compose options dan urli düzeltmeniz yeterli olacaktır. Swagger geldiğinde, sayfadaki metotlar; CreateTablos, CreateTablosNewUser, GetAgeGroupList, GetAvgPaceList,
GetTotalTimeList, GetDistanceList.
    Create Tablos, çalıştırıldığında hazırda olan listeyi database'e yazmaktadır. CreateTablosNewUser, metota yollanılaçak user bilgilerini database'e yazmaktadır. Listeye ek user eklemek
için kullanılır. GetAgeGroupList, database'deki listeyi yaş aralıklarına göre sıralar. GetAvgPaceList, database'deki listeyi avgpace hesabı yaparak yeniden sıralar.(Database e yazmaz her
seferinde yeniden hesaplar ve sıralar.), GetTotalTimeList,  database'deki listeyi totaltime göre sıralar. GetDistanceList, database'deki listeyi totaltime göre sıralar.

    Frontend yazılamamıştır. React.js denenmiştir ama docker üzerine kuramadığım için ve hatalar çözülemediğimden fronted kısmını yazamadım. 