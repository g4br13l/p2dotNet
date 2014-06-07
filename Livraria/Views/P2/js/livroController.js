(function(){
	
	var app = angular.module('livroController', [])

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

	app.controller('EditaLivroController', ['$scope', '$http', function($scope, $http){

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