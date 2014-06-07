(function(){

	var app = angular.module('service', ['ngRoute']);

	app.directive('partialsHeader', function(){
		return {
			restrict: 'E',
			templateUrl: 'partials/header.html'
		};
	});

	// configure our routes
	app.config(function($routeProvider) {
		$routeProvider

			// route for the home page
			.when('/', {
				templateUrl : 'views/home.html',
				controller  : 'IndexController'
			})

			// route for the about page
			.when('/criar', {
				templateUrl : 'views/cadastrar.html',
				controller  : 'CadastroLivroController'
			})

			// route for the contact page
			.when('/edita/:id', {
				templateUrl : 'views/edita.html',
				controller  : 'EditaLivroController'
			})
			.otherwise({
				redirectTo: '/'
			});
	});

	app.controller('CadastroLivroController', ['$scope', '$http', function($scope, $http){

		$scope.livro = { 
			nome: null,
			preco: null,
			dataPublicacao: null,
		}

		this.cadastraLivro = function () {
			$http.post('cadastro', { livro: $scope.livro });
		}

	}]);

	app.controller('EditaLivroController', ['$scope', '$http', '$routeParams',function($scope, $http, $routeParams){

		$scope.livroId = $routeParams.id;


		$scope.livro = this;

		http.get('livro_autor.json').success(function(data){
			$scope.livro = data[1];
		});

	}]);

	app.controller('IndexController', [ '$scope', '$http', function($scope, $http){

		$scope.livros = [];

		$http.get('livro_autor.json').success(function(data){
			$scope.livros = data;
		});

	
	}]);

})();


