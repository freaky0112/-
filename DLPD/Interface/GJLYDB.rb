class GJLYDB
	LV1=2800..3000
	LV2=2600..2800
	LV3=2400..2600
	LV4=2200..2400
	LV5=2000..2200
	LV6=1800..2000
	LV7=1600..1800
	LV8=1400..1600
	LV9=1200..1400
	LV10=1000..1200
	LV11=800..1000
	LV12=600..800
	LV13=400..600
	LV14=200..400
	LV15=0..200
	def getGJLYDB(zs)
		list=[LV1,LV2,LV3,LV4,LV5,LV6,LV7,LV8,LV9,LV10,LV11,LV12,LV13,LV14,LV15]
		i=0
		while zs>0
			if list[i].include?(zs)
				return i+1
			end
			i+=1
		end
		return -1
	end

end
#result=GJLYDB.new();
#puts result.getGJLYDB(1333)
