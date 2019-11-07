local names = {
    {"李", 2000},
    {"王", 2000},
    {"张", 2000},
    {"刘", 2000},
    {"陈", 1500},
    {"杨", 1500},
    {"赵", 1500},
    {"黄", 1500},
    {"周", 1200},
    {"吴", 1200},
    {"徐", 1100},
    {"孙", 1100},
    {"胡", 1000},
    {"朱", 1000},
    {"高", 1000},
    {"林", 900},
    {"何", 900},
    {"郭", 900},
    {"马", 900},
    {"罗", 800},
    {"梁", 800},
    {"宋", 800},
    {"郑", 800},
    {"谢", 700},
    {"韩", 700},
    {"唐", 700},
    {"冯", 700},
    {"于", 700},
    {"董", 600},
    {"萧", 600},
    {"程", 600},
    {"曹", 600},
    {"袁", 600},
    {"邓", 600},
    {"许", 500},
    {"傅", 500},
    {"沈", 500},
    {"曾", 500},
    {"彭", 500},
    {"吕", 500},
    {"苏", 400},
    {"卢", 400},
    {"蒋", 400},
    {"蔡", 400},
    {"贾", 400},
    {"丁", 400},
    {"魏", 400},
    {"薛", 400},
    {"叶", 400},
    {"阎", 400},
    {"阎", 400},
    {"余", 300},
    {"潘", 300},
    {"杜", 300},
    {"戴", 300},
    {"夏", 300},
    {"汪", 300},
    {"田", 300},
    {"任", 300},
    {"姜", 300},
    {"范", 300},
    {"方", 300},
    {"石", 300},
    {"姚", 300},
    {"谭", 300},
    {"廖", 300},
    {"邹", 300},
    {"熊", 200},
    {"金", 200},
    {"陆", 200},
    {"郝", 200},
    {"孔", 200},
    {"白", 200},
    {"崔", 200},
    {"康", 200},
    {"毛", 200},
    {"秦", 200},
    {"江", 200},
    {"史", 200},
    {"顾", 200},
    {"侯", 200},
    {"邵", 200},
    {"孟", 200},
    {"龙", 200},
    {"万", 200},
    {"段", 200},
    {"钱", 200},
    {"汤", 200},
    {"尹", 200},
    {"黎", 200},
    {"易", 200},
    {"常", 200},
    {"武", 200},
    {"乔", 200},
    {"贺", 200},
    {"赖", 200},
    {"龚", 200},
    {"文", 100},
    {"庞", 100},
    {"樊", 100},
    {"殷", 100},
    {"施", 100},
    {"陶", 100},
    {"洪", 100},
    {"翟", 100},
    {"安", 100},
    {"颜", 100},
    {"倪", 100},
    {"严", 100},
    {"牛", 100},
    {"温", 100},
    {"季", 100},
    {"俞", 100},
    {"章", 100},
    {"鲁", 100},
    {"葛", 100},
    {"伍", 100},
    {"韦", 100},
    {"申", 100},
    {"尤", 100},
    {"毕", 100},
    {"聂", 100},
    {"焦", 100},
    {"向", 100},
    {"柳", 100},
    {"邢", 100},
    {"路", 100},
    {"岳", 100},
    {"齐", 100},
    {"梅", 100},
    {"莫", 100},
    {"庄", 100},
    {"辛", 100},
    {"管", 100},
    {"祝", 100},
    {"左", 100},
    {"涂", 100},
    {"谷", 100},
    {"祁", 100},
    {"时", 100},
    {"舒", 100},
    {"耿", 100},
    {"牟", 80},
    {"卜", 80},
    {"詹", 80},
    {"关", 80},
    {"苗", 80},
    {"凌", 80},
    {"费", 80},
    {"纪", 80},
    {"靳", 80},
    {"盛", 80},
    {"童", 80},
    {"欧", 80},
    {"甄", 80},
    {"项", 80},
    {"成", 80},
    {"游", 80},
    {"阳", 80},
    {"裴", 80},
    {"席", 80},
    {"卫", 80},
    {"查", 80},
    {"屈", 80},
    {"鲍", 80},
    {"霍", 80},
    {"翁", 80},
    {"甘", 80},
    {"景", 80},
    {"薄", 80},
    {"单", 80},
    {"包", 80},
    {"司", 80},
    {"柏", 80},
    {"宁", 80},
    {"柯", 80},
    {"阮", 80},
    {"桂", 80},
    {"欧阳", 80},
    {"解", 80},
    {"强", 80},
    {"柴", 80},
    {"华", 80},
    {"车", 80},
    {"冉", 80},
    {"房", 80},
    {"边", 80},
    {"吉", 80},
    {"饶", 80},
    {"刁", 80},
    {"瞿", 80},
    {"戚", 80},
    {"丘", 80},
    {"古", 80},
    {"米", 80},
    {"池", 80},
    {"滕", 80},
    {"晋", 80},
    {"邬", 80},
    {"臧", 80},
    {"宫", 80},
    {"全", 80},
    {"廉", 80},
    {"简", 80},
    {"娄", 80},
    {"盖", 80},
    {"符", 80},
    {"奚", 80},
    {"穆", 80},
    {"党", 80},
    {"燕", 80},
    {"郎", 80},
    {"冀", 80},
    {"谈", 80},
    {"姬", 80},
    {"屠", 80},
    {"连", 80},
    {"郜", 80},
    {"晏", 70},
    {"栾", 70},
    {"郁", 70},
    {"郁", 70},
    {"商", 70},
    {"蒙", 70},
    {"计", 70},
    {"喻", 70},
    {"窦", 70},
    {"敖", 70},
    {"糜", 70},
    {"鄢", 70},
    {"冷", 70},
    {"卓", 70},
    {"花", 70},
    {"仇", 70},
    {"艾", 70},
    {"蓝", 70},
    {"都", 70},
    {"巩", 70},
    {"井", 70},
    {"仲", 70},
    {"乐", 70},
    {"虞", 70},
    {"卞", 70},
    {"封", 60},
    {"竺", 60},
    {"楚", 60},
    {"佟", 60},
    {"匡", 60},
    {"宗", 60},
    {"应", 60},
    {"巫", 60},
    {"鞠", 60},
    {"桑", 60},
    {"荆", 60},
    {"明", 60},
    {"沙", 60},
    {"伏", 60},
    {"岑", 60},
    {"习", 60},
    {"胥", 60},
    {"和", 60},
    {"蔺", 60},
    {"楮", 50},
    {"东", 50},
    {"广", 50},
    {"司马", 50},
    {"荀", 15},
    {"师", 15},
    {"闻人", 15},
    {"水", 10},
    {"云", 10},
    {"昌", 10},
    {"凤", 10},
    {"酆", 10},
    {"雷", 10},
    {"皮", 10},
    {"元", 10},
    {"平", 10},
    {"湛", 10},
    {"禹", 10},
    {"狄", 10},
    {"贝", 10},
    {"茅", 10},
    {"闽", 10},
    {"麻", 10},
    {"危", 10},
    {"锺", 10},
    {"骆", 10},
    {"支", 10},
    {"昝", 10},
    {"经", 10},
    {"裘", 10},
    {"缪", 10},
    {"干", 10},
    {"宣", 10},
    {"贲", 10},
    {"杭", 10},
    {"诸", 10},
    {"钮", 10},
    {"嵇", 10},
    {"滑", 10},
    {"荣", 10},
    {"羊", 10},
    {"於", 10},
    {"惠", 10},
    {"麹", 10},
    {"家", 10},
    {"芮", 10},
    {"羿", 10},
    {"储", 10},
    {"汲", 10},
    {"邴", 10},
    {"松", 10},
    {"富", 10},
    {"乌", 10},
    {"巴", 10},
    {"弓", 10},
    {"牧", 10},
    {"隗", 10},
    {"山", 10},
    {"宓", 10},
    {"蓬", 10},
    {"郗", 10},
    {"班", 10},
    {"仰", 10},
    {"秋", 10},
    {"伊", 10},
    {"暴", 10},
    {"斜", 10},
    {"厉", 10},
    {"戎", 10},
    {"祖", 10},
    {"束", 10},
    {"幸", 10},
    {"韶", 10},
    {"蓟", 10},
    {"印", 10},
    {"宿", 10},
    {"怀", 10},
    {"蒲", 10},
    {"邰", 10},
    {"从", 10},
    {"鄂", 10},
    {"索", 10},
    {"咸", 10},
    {"籍", 10},
    {"阴", 10},
    {"能", 10},
    {"苍", 10},
    {"双", 10},
    {"闻", 10},
    {"莘", 10},
    {"贡", 10},
    {"劳", 10},
    {"逄", 10},
    {"扶", 10},
    {"堵", 10},
    {"宰", 10},
    {"郦", 10},
    {"雍", 10},
    {"郤", 10},
    {"璩", 10},
    {"濮", 10},
    {"寿", 10},
    {"通", 10},
    {"扈", 10},
    {"郏", 10},
    {"浦", 10},
    {"尚", 10},
    {"农", 10},
    {"别", 10},
    {"充", 10},
    {"慕", 10},
    {"茹", 10},
    {"宦", 10},
    {"鱼", 10},
    {"容", 10},
    {"慎", 10},
    {"戈", 10},
    {"庾", 10},
    {"终", 10},
    {"暨", 10},
    {"居", 10},
    {"衡", 10},
    {"步", 10},
    {"满", 10},
    {"弘", 10},
    {"国", 10},
    {"寇", 10},
    {"禄", 10},
    {"阙", 10},
    {"殳", 10},
    {"沃", 10},
    {"利", 10},
    {"蔚", 10},
    {"越", 10},
    {"夔", 10},
    {"隆", 10},
    {"厍", 10},
    {"晁", 10},
    {"勾", 10},
    {"融", 10},
    {"訾", 10},
    {"阚", 10},
    {"那", 10},
    {"空", 10},
    {"毋", 10},
    {"乜", 10},
    {"养", 10},
    {"须", 10},
    {"丰", 10},
    {"巢", 10},
    {"蒯", 10},
    {"相", 10},
    {"后", 10},
    {"红", 10},
    {"权", 10},
    {"逑", 10},
    {"益", 10},
    {"桓", 10},
    {"公", 10},
    {"万俟", 10},
    {"上官", 10},
    {"夏侯", 10},
    {"诸葛", 10},
    {"东方", 10},
    {"赫连", 10},
    {"皇甫", 10},
    {"尉迟", 10},
    {"公羊", 10},
    {"澹台", 10},
    {"公冶", 10},
    {"宗政", 10},
    {"濮阳", 10},
    {"淳于", 10},
    {"单于", 10},
    {"太叔", 10},
    {"申屠", 10},
    {"公孙", 10},
    {"仲孙", 10},
    {"轩辕", 10},
    {"令狐", 10},
    {"锺离", 10},
    {"宇文", 10},
    {"长孙", 10},
    {"慕容", 10},
    {"鲜于", 10},
    {"闾丘", 10},
    {"司徒", 10},
    {"司空", 10},
    {"丌官", 10},
    {"司寇", 10},
    {"仉", 10},
    {"督", 10},
    {"子车", 10},
    {"颛孙", 10},
    {"端木", 10},
    {"巫马", 10},
    {"公西", 10},
    {"漆雕", 10},
    {"乐正", 10},
    {"壤驷", 10},
    {"公良", 10},
    {"拓拔", 10},
    {"夹谷", 10},
    {"宰父", 10},
    {"谷梁", 10},
    {"法", 10},
    {"汝", 10},
    {"钦", 10},
    {"段干", 10},
    {"百里", 10},
    {"东郭", 10},
    {"南门", 10},
    {"呼延", 10},
    {"归", 10},
    {"海", 10},
    {"羊舌", 10},
    {"微生", 10},
    {"帅", 10},
    {"缑", 10},
    {"亢", 10},
    {"况", 10},
    {"后", 10},
    {"有", 10},
    {"琴", 10},
    {"梁丘", 10},
    {"左丘", 10},
    {"东门", 10},
    {"西门", 10},
    {"佘", 10},
    {"佴", 10},
    {"伯", 10},
    {"赏", 10},
    {"南宫", 10},
    {"墨", 10},
    {"哈", 10},
    {"谯", 10},
    {"笪", 10},
    {"年", 10},
    {"爱", 10},
    {"第五", 10},
    {"言", 10},
    {"福", 10},
}
SetTextWeightList("chinese_family_name", names)