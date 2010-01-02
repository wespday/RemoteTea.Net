/*
 * demo2.x -- demonstrates and tests some jrpcgen features. It doesn't
 *           boil down to a useful example, it just checks a few things
 *           within code generation.
 *
 *           This test tests code generation with a missing program
 *           section, which is now accepted.
 *
 * To compile, use
 *   java -jar jrpcgen.jar -p tests.org.acplt.oncrpc.jrpcgen -nobackup demo-2.x
 */

/* Check that dependencies are followed when dumping constants */
const C_B = C_A;
const C_A = C_C;
const C_C = 42;

/* Check enumerations */
enum ENUMBAZ2 { E_BAZ = C_B };

enum ENUMFOO2 {
    FOO, BAR, BAZ_1 = C_B, BAZ_2, BAZ_3 = E_BAZ
};

struct TREE2 {
	string key<>;
	string value<>;
	struct TREE2 *left;
	struct TREE2 *right;
};

/* End of file demo2.x */
