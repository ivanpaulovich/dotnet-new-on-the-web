#!/bin/bash
DOCKERPULL=`docker pull ivanpaulovich/dotnet-new-on-the-web:workerconsole`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
	echo "Updating"
	docker stop workerconsole
	docker rm workerconsole
	docker run -d --name workerconsole \
		-e modules__2__properties__OutputPath=E:\\test\\output\\ \
		-e modules__2__properties__ZipDeliveryPath=E:\\test\\orders\\ \
		-e modules__2__properties__StorageAccountName=orders2caju \
		-e modules__2__properties__AccessKey=D949P99wWM8i4cttbdUDJv5zNbI/In7OJpBgen8lTO/8rk5ov43WnuPTV/EBWEgXnAS+4VwfNNZaapST0zYVMg== \
		-e modules__3__properties__BrokerList=10.0.75.1:9092 \
		-e modules__3__properties__Topic=template-orders-02 \
		ivanpaulovich/dotnet-new-on-the-web:workerconsole
else
	echo "Image is already updated"
fi