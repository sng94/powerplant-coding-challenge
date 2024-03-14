Hello! This is my submission for Power Plant Coding Challange. Dockerfile is already set. In order to build the image:

docker build -t production-plan-challenge .

In order to run the container:

docker run -d -p 8888:8888 --name production-plan-challenge production-plan-challenge

When the container is running, you will be able to use the POST endpoint on localhost:8888/productionplan.