Quick Notes to Run on minikube:

1. Make sure minikube is running `minikube start`
2. kubectl apply -f deployment.yml
3. kubectl apply -f service.yml
4. Create a tunnel to the service `minikube service tripbooking-api-service --url`



Set-up Notes:

1. Followed minikube documentation to automatically include minikube on local docker commands
	https://minikube.sigs.k8s.io/docs/handbook/pushing/
2. TBA